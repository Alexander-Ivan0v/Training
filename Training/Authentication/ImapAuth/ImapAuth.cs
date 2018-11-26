using Training.Authentication.MyAuth;
using System;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using Microsoft.Extensions.Configuration;

namespace Training.Authentication.ImapAuth
{
    public class ImapAuth : IMyAuth
    {
        private ImapClient _client = null;
        private readonly IConfiguration _config;

        public ImapAuth(IConfiguration config)
        {
            _config = config;            
        }

        public bool Authorize(string login, string pass)
        {
            return AuthorizeAsync(login, pass).Result;
        }
        public async Task<bool> AuthorizeAsync(string login, string pass)
        {
            try
            {
                UInt32 port = UInt16.TryParse(_config["Imap:Port"], out var tmp) ? tmp : UInt32.Parse("993");
                _client = new ImapClient();
                // For demo-purposes, accept all SSL certificates
                _client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await _client.ConnectAsync(_config["Imap:Server"], int.Parse(_config["Imap:Port"]), true);
                await _client.AuthenticateAsync(login, pass);
                return true;                
            }
            catch
            {
                return false;
            }
            finally
            {
                if(_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }
            }
        }
    }
}
