# Ticket-Booking-App
Client-server application for booking concert tickets

Проект состоит из 3 приложений:
1) TicketBookingAPI - Web API ASP.NET Core. <br/>
Работает на https://localhost:7249 <br/>
Для работы нужно заменить строку подключения к бд SQL Server (В файле appsettings.json значение с ключом 'TicketBookingConnection'). <br/>

2) react-ticket-booking-app - React web app <br/>
Для оплаты через paypal необходимо заменить clientId в файле src/components/paypal-buttons.js:57. <br/>
Для запуска необходимо прописать 'npm start' <br/>
Главная страница: http://localhost:3000/concerts/concert-list <br/>

3) IdentityServer - IdentityServer4 web app <br/>
Работает на https://localhost:7181 <br/>
Для работы необходимо заменить строку подключения к бд SQL Server (В файле appsettings.json значение с ключом 'IdentityConnection'). <br/>
