# Ticket-Booking-App
Client-server application for booking concert tickets

Проект состоит из 3 приложений:
1) TicketBookingAPI - Web API ASP.NET Core.
Работает на https://localhost:7249
Для работы нужно заменить строку подключения к бд SQL Server (В файле appsettings.json значение с ключом 'TicketBookingConnection').

2) react-ticket-booking-app - React web app
Для оплаты через paypal необходимо заменить clientId в файле src/components/paypal-buttons.js:57.
Для запуска необходимо прописать 'npm start'
Главная страница: http://localhost:3000/concerts/concert-list

3) IdentityServer - IdentityServer4 web app
Работает на https://localhost:7181
Для работы необходимо заменить строку подключения к бд SQL Server (В файле appsettings.json значение с ключом 'IdentityConnection').
