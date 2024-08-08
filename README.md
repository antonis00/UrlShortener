# UrlShortener

This is a basic .Net application that includes a URL shortener service. The application is written in C#.

## Current functionality

The application currently has two routes:

1. `POST /shorten`: This route should accept a URL and return a unique shortened URL. The original URL and the corresponding shortened URL should be stored in a database.
2. `GET /:shortUrl`: This route should accept a shortened URL, look it up in the database, and redirect to the original URL.

## How to run the application

Prerequisites: Docker (with docker compose)
1. Move the two provided files (docker-compose.yml and .env) in a new directory
2. In this new directory, run the command: docker compose up.

## How to use web API

POST request that shortens a long url: 
  Path: https://localhost:8080/api/UrlShortener/shorten
  Example: curl -X POST "https://localhost:44307/api/UrlShortener/shorten" ^-H "Content-Type: application/json" ^-d "{\"longUrl\":\"https://example.com/information-architecture-gitlab-backend/kanban-ux-aspnet\"}"
  
GET request that returns the long url that corresponds to the given shortened url: 
  Path: https://localhost:8080/api/UrlShortener/shortUrl?shortUrl=shortString
  Example: curl -X GET "https://localhost:8080/api/UrlShortener/shortUrl?shortUrl=shortenedUrl"

Enjoy!
