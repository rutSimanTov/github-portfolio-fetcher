

# GitHub Integration API

## Overview

The **GitHub Integration API** is a web service designed to provide seamless integration with GitHub. It offers functionalities such as fetching a user's repository portfolio, searching repositories in a specific language, and caching results for performance improvement. Built using **ASP.NET Core** and **Octokit**, it allows you to interact with GitHub data efficiently.

This API is structured with multiple services:

* **Service Layer**: Provides core functionality for interacting with GitHub repositories.
* **API Layer**: Exposes endpoints to access the service layer and cache GitHub data using an in-memory cache.

## Features

* **Repository Search**: Search repositories on GitHub based on repository name, user, and programming language.
* **Portfolio Retrieval**: Fetch details about a user's GitHub repositories, including stars, pull requests, last commit, and used programming languages.
* **Caching**: Cache the portfolio data for faster response times using an in-memory cache.
* **GitHub Authentication**: Uses a GitHub personal access token for authentication when accessing user data.

## Technologies Used

* **.NET 7**: The application is built using .NET 7, utilizing its features such as nullable enablement, implicit using directives, and dependency injection.
* **Octokit**: A .NET client library for interacting with the GitHub API.
* **Swagger**: API documentation tool for easy testing and exploration of the API endpoints.
* **Microsoft.Extensions.Caching.Memory**: Caching mechanism to reduce redundant API calls to GitHub.
* **ASP.NET Core**: Framework for building the web API.

## Setup

### Prerequisites

1. **GitHub Personal Access Token**:

   * Create a GitHub personal access token [here](https://github.com/settings/tokens).
   * This token is used to authenticate API requests to GitHub.

2. **.NET SDK**:

   * Ensure you have the [.NET 7 SDK](https://dotnet.microsoft.com/download) installed.

### Environment Variables

Make sure to configure your GitHub credentials in `appsettings.json` or through environment variables.

```json
{
  "GitHubIntegrationOptions": {
    "UserName": "your-username",
    "Token": "your-personal-access-token"
  }
}
```

Alternatively, you can configure these settings using the `IConfiguration` interface in the `Startup` class or `Program.cs`.

### Running the Application

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/yourproject.git
   cd yourproject
   ```

2. Build and run the application:

   ```bash
   dotnet build
   dotnet run
   ```

3. The API will be available at `http://localhost:5073` or `https://localhost:7035`.

4. Access the API documentation through Swagger UI at `http://localhost:5073/swagger`.

## Endpoints

### `GET /api/github/{repo_name}`

Search for repositories in C# by name.

* **Parameters**:

  * `repo_name` (string): The name of the repository to search for.
* **Response**: A list of repositories matching the search query in C#.

### `GET /api/github`

Fetch the portfolio of a GitHub user.

* **Response**: A list of the user's repositories, including the repository name, stars, pull requests count, last commit date, and used programming languages.

### `GET /api/github/{repoName}/{userName}/{language}`

Search for repositories by name, user, and programming language.

* **Parameters**:

  * `repoName` (string): The name of the repository.
  * `userName` (string): The GitHub username.
  * `language` (string): The programming language used in the repository.

* **Response**: A list of repositories that match the query.

## Example Requests

### Search for Repositories in C#:

```http
GET /api/github/awesome-repo
```

### Get User's GitHub Portfolio:

```http
GET /api/github
```

### Search Repositories by Name, User, and Language:

```http
GET /api/github/awesome-repo/johndoe/csharp
```

## Cache Management

* The portfolio data is cached for **30 seconds** (absolute expiration) and **10 seconds** (sliding expiration) to reduce the number of API calls to GitHub.
* The cache key used is `UserPortfolioKey`.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

* **Octokit** for the GitHub API client.
* **ASP.NET Core** and **Swagger** for building and documenting the API.
* **Microsoft.Extensions.Caching.Memory** for caching functionality.

