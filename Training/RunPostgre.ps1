if (!(Test-NetConnection -ComputerName localhost -Port 5432 -Verbose).TcpTestSuccessfull) {
    'Executing PostgreSQL...'
    docker run -p 5432:5432 -e POSTGRES_PASSWORD=P@ssw0rd -d postgres
    'Executing PGAdmin...'
    docker run -p 80:80 -e "PGADMIN_DEFAULT_EMAIL=user@domain.com" -e "PGADMIN_DEFAULT_PASSWORD=P@ssw0rd" -d dpage/pgadmin4
}

# dotnet ef migrations add Initial
# dotnet ef migrations remove