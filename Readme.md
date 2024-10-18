## How to create a solution with different projects with VSCode

- `mkdir SolutionName`
- `cd SolutionName`
- `dotnet new sln -n SolutionName`
- `dotnet new console -n Project1`
- `dotnet sln add Project1/Project1.csproj`

## How to configure run debug in VSCode

### Configure .vscode/launch.json
Can setup multiple project run configurations
### Configure .vscode/task.json
`lable` of the task must be identical with `preLaunchTask` in launch.json

In `Run and Debug` panel, select a project from the dropdown menu.

## Difference btw `WebApi` `WebApi2` & `WebApplication1`

`WebApi` is created using traditional `Main` instead of `top-level statements`
`dotnet new webapi -n WebApi --use-program-main`

`WebApi2` is created using controllers
`dotnet new webapi --use-controllers -o WebApi2`

`WebApplication1` is created using VSCode UI
by default `top-level statements` 