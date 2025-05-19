# .NET Core Cloud Foundry Test Application

This is a minimal ASP.NET Core application designed to test the .NET Core buildpack for Cloud Foundry.

## Project Structure

- `Program.cs` - Main application file with minimal API endpoints
- `CloudFoundryTest.csproj` - Project file for .NET 7.0
- `manifest.yml` - Cloud Foundry deployment manifest

## API Endpoints

The application provides two endpoints:
- `/` - Returns a simple greeting message
- `/env` - Returns some Cloud Foundry environment variables to verify deployment

## Deployment Instructions

1. Make sure you have the Cloud Foundry CLI installed and are logged in:
   ```
   cf login -a <your-cf-api-endpoint>
   ```

2. Navigate to the project directory and push the application:
   ```
   cf push
   ```

3. If you want to override the default application name in the manifest:
   ```
   cf push my-custom-app-name
   ```

## Testing the Buildpack

After deployment, you can verify the application is running by:

1. Checking the application status:
   ```
   cf apps
   ```

2. Accessing the application URL (provided after successful deployment)

3. Checking the logs:
   ```
   cf logs dotnetcore-cf-test --recent
   ```

4. Checking environment variables and buildpack details:
   ```
   cf env dotnetcore-cf-test
   ```

## Troubleshooting

If the application fails to deploy:

1. Check the staging logs:
   ```
   cf logs dotnetcore-cf-test --recent
   ```

2. Verify the buildpack is available:
   ```
   cf buildpacks
   ```

3. Try specifying the buildpack version:
   ```
   cf push -b https://github.com/cloudfoundry/dotnet-core-buildpack.git
   ```

## Customizing

You can modify `Program.cs` to add more functionality or test specific aspects of the buildpack. Update the `manifest.yml` file to change memory allocation, instance count, or environment variables.