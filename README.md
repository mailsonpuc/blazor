# Portifolio Blazor

Repositório com dois projetos Blazor:

1. `projetoBlazorPortifolio/Portifolio` (Blazor com Razor Components)
2. `projetoBlazorTarefas/BlazorTarefas` (Blazor interativo com Server + WebAssembly habilitado)

## 1. projetoBlazorPortifolio/Portifolio

- Tipo: Razor Components em ASP.NET Core (renderização no servidor + UI estática)
- Interatividade: básica do Blazor (com `@code`, eventos, binding quando você cria). O pipeline:
  - `builder.Services.AddRazorComponents();`
  - `app.MapRazorComponents<App>();`
- Uso esperado:
  - Página inicial (`Home.razor`), `Error.razor`, `NotFound.razor`
  - Layout com `MainLayout`, `NavMenu`.

## 2. projetoBlazorTarefas/BlazorTarefas

- Tipo: Aplicação Blazor híbrida (suporte a Server e WebAssembly interativo)
- Interatividade configurada em `Program.cs`:
  - `builder.Services.AddRazorComponents()`
  - `AddInteractiveServerComponents()`
  - `AddInteractiveWebAssemblyComponents()`
  - `app.MapRazorComponents<App>()`
    - `.AddInteractiveServerRenderMode()`
    - `.AddInteractiveWebAssemblyRenderMode()`
    - `.AddAdditionalAssemblies(...)`
- Isso significa que o mesmo app pode ser renderizado tanto em modo interativo Server como WebAssembly dependendo da rota/cliente.
- Páginas de foco: `Tarefas.razor`, `Weather.razor`, `Home.razor` etc.

## Como rodar

1. Abra terminal na raiz do repositório.
2. Para o projeto `Portifolio`:
   - `cd projetoBlazorPortifolio/Portifolio`
   - `dotnet run`
3. Para o projeto `BlazorTarefas`:
   - `cd projetoBlazorTarefas/BlazorTarefas`
   - `dotnet run`
