#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TicketBooking.WebAPI/TicketBooking.WebAPI.csproj", "TicketBooking.WebAPI/"]
COPY ["TicketBooking.Application/TicketBooking.Application.csproj", "TicketBooking.Application/"]
COPY ["TicketBooking.Domain/TicketBooking.Domain.csproj", "TicketBooking.Domain/"]
COPY ["TicketBooking.Email/TicketBooking.Email.csproj", "TicketBooking.Email/"]
COPY ["TicketBooking.Persistence/TicketBooking.Persistence.csproj", "TicketBooking.Persistence/"]
RUN dotnet restore "TicketBooking.WebAPI/TicketBooking.WebAPI.csproj"
COPY . .
WORKDIR "/src/TicketBooking.WebAPI"
RUN dotnet build "TicketBooking.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketBooking.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketBooking.WebAPI.dll"]