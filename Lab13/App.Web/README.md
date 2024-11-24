- Login
- Log out
- Showing the user profile
- Protecting routes using the authentication guard
- Calling APIs with automatically-attached bearer tokens

## Configuration

The sample needs to be configured with your Auth0 domain and client ID in order to work. In the root of the sample, copy `auth_config.json.example` and rename it to `auth_config.json`. Open the file and replace the values with those from your Auth0 tenant:

```json
{
  "domain": "<YOUR AUTH0 DOMAIN>",
  "clientId": "<YOUR AUTH0 CLIENT ID>",
  "audience": "<YOUR AUTH0 API AUDIENCE IDENTIFIER>"
}
```

## Build

Run `npm build` to build the project. The build artifacts will be stored in the `dist/login-demo` directory. Use the `--prod` flag for a production build.

To build and run a production bundle and serve it, run `npm run prod`. The application will run on `http://localhost:3000`.

