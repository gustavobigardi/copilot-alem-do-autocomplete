# Referências

Fontes usadas na palestra. Tudo foi conferido em 22/09/2026 contra a documentação do GitHub (docs.github.com), os changelogs (github.blog/changelog) e o Microsoft Learn. O Copilot muda toda semana: as páginas "GitHub Copilot weekly releases" são o lugar para ver o que mudou depois desta data.

## Linha do tempo e nomes atuais

- [Research: quantifying GitHub Copilot's impact on developer productivity and happiness](https://github.blog/news-insights/research/research-quantifying-github-copilots-impact-on-developer-productivity-and-happiness/) (2022): o Copilot em preview em junho de 2021; o estudo dos 55%.
- [GitHub Copilot CLI is now generally available](https://github.blog/changelog/2026-02-25-github-copilot-cli-is-now-generally-available/) (25/02/2026).
- [Research, plan, and code with Copilot cloud agent](https://github.blog/changelog/2026-04-01-research-plan-and-code-with-copilot-cloud-agent/) (01/04/2026): o "coding agent" passa a se chamar **cloud agent**.
- [GitHub Copilot is moving to usage-based billing](https://github.blog/news-insights/company-news/github-copilot-is-moving-to-usage-based-billing/) (27/04/2026) e [Updates to GitHub Copilot billing and plans](https://github.blog/changelog/2026-06-01-updates-to-github-copilot-billing-and-plans/) (01/06/2026): fim dos "premium requests", **AI Credits** e o plano **Max**.
- [GitHub Copilot app generally available](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/) (17/06/2026) e [GitHub Copilot app available to all](https://github.blog/changelog/2026-07-07-github-copilot-app-available-to-all/) (07/07/2026, inclusive Free).
- [Agent Plugins 1.0 in VS Code, Copilot CLI, and the Copilot app](https://github.blog/changelog/2026-08-12-agent-plugins-1-0-in-vs-code-copilot-cli-and-the-copilot-app/) (12/08/2026).
- [GitHub Universe 2026](https://githubuniverse.com/): 28 e 29/10/2026, San Francisco.
- Índice: [GitHub Changelog, label Copilot](https://github.blog/changelog/label/copilot/).

## Planos, AI Credits e modelos

- [Plans for GitHub Copilot](https://docs.github.com/en/copilot/get-started/plans) e [github.com/features/copilot/plans](https://github.com/features/copilot/plans): tabela de planos, o que o Free inclui (2.000 completions, CLI, app, só modelo auto; sem cloud agent e sem code review), cloud agent "Included" de Student a Max.
- [Billing for individual Copilot plans](https://docs.github.com/en/copilot/concepts/billing-and-usage/individuals/billing): "1 AI credit = $0.01 USD"; créditos base + flex; "Unused credits are forfeited"; completions e next edit suggestions não consomem créditos nos planos pagos; o que fazer quando acabam.
- [Models and pricing](https://docs.github.com/en/copilot/reference/copilot-billing/models-and-pricing): preço por modelo por milhão de tokens (base do exemplo Sonnet 5 × Fable 5.1 no slide 10).
- [Supported AI models](https://docs.github.com/en/copilot/reference/ai-models/supported-models) e [Configure cost and quality in Copilot auto model selection](https://github.blog/changelog/2026-09-14-configure-cost-and-quality-in-copilot-auto-model-selection) (14/09/2026): perfis efficiency, balance e intelligence.
- [Upcoming deprecation of selected GitHub Copilot models in mid-October](https://github.blog/changelog/2026-09-18-upcoming-deprecation-of-selected-github-copilot-models-in-mid-october) (18/09/2026): GPT-5.5, GPT-5.4, GPT-5.4 mini, GPT-5 mini, Gemini 3.7 Flash e Grok 4.5 saem em 19/10/2026.
- [Upcoming changes to GitHub Copilot policies and billing](https://github.blog/changelog/2026-08-28-upcoming-changes-to-github-copilot-policies-and-billing) (28/08/2026): em 28/09 o padrão do code review vira Balanced e a retenção do chat muda.
- [Project HydraFusion](https://github.blog/ai-and-ml/github-copilot/project-hydrafusion-frontier-quality-via-multi-model-orchestration/) (04/09/2026): roteamento entre modelos no CLI, research preview.

## GitHub Copilot app (desktop)

- [About the GitHub Copilot app](https://docs.github.com/en/copilot/concepts/agents/github-copilot-app): "built on GitHub Copilot CLI"; disponível em todos os planos.
- [Getting started](https://docs.github.com/en/copilot/how-tos/github-copilot-app/getting-started), [Quickstart](https://docs.github.com/en/copilot/get-started/quickstart-copilot-app) e [Working with agent sessions](https://docs.github.com/en/copilot/how-tos/github-copilot-app/agent-sessions): New worktree / Local repository / Cloud sandbox; modos Interactive, Plan e Autopilot; Chats sem branch; `Changes`; `/security-review`; agente rubber duck; atalhos em Help → Keyboard Shortcuts.
- [Managing issues and pull requests](https://docs.github.com/en/copilot/how-tos/github-copilot-app/managing-issues-and-pull-requests), [Using automations](https://docs.github.com/en/copilot/how-tos/github-copilot-app/using-automations), [Canvas extensions](https://docs.github.com/en/copilot/how-tos/github-copilot-app/working-with-canvas-extensions), [Customize the app](https://docs.github.com/en/copilot/how-tos/github-copilot-app/customize-github-copilot-app), [Slash commands](https://docs.github.com/en/copilot/reference/github-copilot-app-reference/slash-commands), [Deep links](https://docs.github.com/en/copilot/how-tos/github-copilot-app/open-with-deep-links).
- Changelogs do app: [Customize tab GA](https://github.blog/changelog/2026-08-25-github-copilot-app-customize-tab-is-generally-available/) (25/08), [Jira](https://github.blog/changelog/2026-09-10-github-copilot-weekly-releases-september-7/) (10/09), [Sentry](https://github.blog/changelog/2026-09-18-github-copilot-weekly-releases-september-14/) (18/09). Versões: [github/app](https://github.com/github/app) (1.1.23 na máquina da demo).

## Copilot CLI

- [About GitHub Copilot CLI](https://docs.github.com/en/copilot/concepts/agents/copilot-cli/about-copilot-cli), [Using Copilot CLI](https://docs.github.com/en/copilot/how-tos/copilot-cli/use-copilot-cli/overview) e [CLI command reference](https://docs.github.com/en/copilot/reference/copilot-cli-reference/cli-command-reference): `copilot init`, `/init`, `/agent`, `/skills`, `/mcp`, `/plan`, `/delegate`, `/fleet`, `/review`, `/rubber-duck`, `--allow-all-tools`, `--auto-tier`, `--reasoning-effort`.
- [Allowing tools](https://docs.github.com/en/copilot/how-tos/copilot-cli/use-copilot-cli/allowing-tools) e [Autopilot](https://docs.github.com/en/copilot/concepts/agents/copilot-cli/autopilot): o que pede aprovação; "strongly recommended that you only use these options in an isolated environment".
- [Cloud and local sandboxes](https://github.blog/changelog/2026-06-02-cloud-and-local-sandboxes-for-github-copilot-now-in-public-preview/) (02/06/2026).
- [Responsible use of Copilot CLI](https://docs.github.com/en/copilot/responsible-use/copilot-cli): "You are ultimately responsible"; pode gerar código igual a código público "even if the 'Suggestions matching public code' policy is set to 'Block'".

## Contexto compartilhado

- [Customization cheat sheet](https://docs.github.com/en/copilot/reference/customization-cheat-sheet) e [Custom instructions support](https://docs.github.com/en/copilot/reference/custom-instructions-support): a matriz de quais superfícies leem cada arquivo (base do slide 20).
- [Adding repository custom instructions](https://docs.github.com/en/copilot/how-tos/configure-custom-instructions/add-repository-instructions): `.github/copilot-instructions.md`, `.github/instructions/*.instructions.md` com `applyTo`, `AGENTS.md`; no GitHub.com as instruções por caminho valem só para cloud agent e code review.
- [Response customization](https://docs.github.com/en/copilot/concepts/prompting/response-customization): precedência pessoal > repositório > organização; prompt files só em editores.
- [About custom agents](https://docs.github.com/en/copilot/concepts/agents/cloud-agent/about-custom-agents) e [Create custom agents for the CLI](https://docs.github.com/en/copilot/how-tos/copilot-cli/customize-copilot/create-custom-agents-for-cli): `.github/agents/*.agent.md`, frontmatter `name`, `description`, `tools`.
- [About agent skills](https://docs.github.com/en/copilot/concepts/agents/about-agent-skills) e [Add skills to the CLI](https://docs.github.com/en/copilot/how-tos/copilot-cli/customize-copilot/add-skills): `.github/skills/<nome>/SKILL.md`; funciona em cloud agent, code review, CLI, app e editores. Padrão aberto: [agentskills](https://github.com/agentskills/agentskills).
- [Hooks](https://docs.github.com/en/copilot/concepts/agents/hooks), [About plugins](https://docs.github.com/en/copilot/concepts/agents/about-plugins) e [github/awesome-copilot](https://github.com/github/awesome-copilot).
- [Copilot Memory](https://docs.github.com/en/copilot/concepts/agents/copilot-memory): fatos do repositório e preferências; expira em 28 dias sem uso.
- [Copilot Spaces](https://docs.github.com/en/copilot/concepts/context/spaces): contexto organizado no GitHub.com, em qualquer plano.

## MCP

- [About Model Context Protocol](https://docs.github.com/en/copilot/concepts/context/mcp), [Add MCP servers to the CLI](https://docs.github.com/en/copilot/how-tos/copilot-cli/customize-copilot/add-mcp-servers) (`~/.copilot/mcp-config.json`, `.mcp.json`, `.github/mcp.json`; servidores de projeto só carregam em pasta confiável) e [MCP and the cloud agent](https://docs.github.com/en/copilot/concepts/agents/cloud-agent/mcp-and-cloud-agent) (configuração própria no repositório; GitHub MCP e Playwright ligados por padrão).
- [Microsoft Learn MCP Server](https://learn.microsoft.com/training/support/mcp): `https://learn.microsoft.com/api/mcp`, sem autenticação, sem custo. [GitHub MCP Registry](https://github.com/mcp).

## Cloud agent e code review

- [About Copilot cloud agent](https://docs.github.com/en/copilot/concepts/agents/cloud-agent/about-cloud-agent): ambiente efêmero no GitHub Actions, 59 minutos por sessão, um repositório e uma branch por tarefa, custo em créditos e minutos do Actions.
- [Assign Copilot to an issue](https://docs.github.com/copilot/how-tos/use-copilot-agents/coding-agent/assign-copilot-to-an-issue), [Start Copilot sessions](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/cloud-agent/start-copilot-sessions), [Use the cloud agent on GitHub](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/cloud-agent/use-cloud-agent-on-github): PR em draft, "View session", `@copilot`.
- [Risks and mitigations](https://docs.github.com/en/copilot/concepts/agents/cloud-agent/risks-and-mitigations) e [Customize the agent firewall](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/cloud-agent/customize-the-agent-firewall): só push em `copilot/*`; "must be reviewed and merged by a human"; workflows exigem aprovação; firewall por padrão.
- [Customizing the development environment](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/customize-the-agent-environment): `copilot-setup-steps.yml`.
- [About Copilot code review](https://docs.github.com/en/copilot/concepts/agents/code-review): planos, Lite e Balanced, custo, o que ele lê do repositório. Changelogs: [pode aprovar PRs](https://github.blog/changelog/2026-09-01-copilot-code-review-can-now-approve-pull-requests) (01/09), [auto-resolução](https://github.blog/changelog/2026-09-11-auto-resolution-and-analysis-updates-in-copilot-code-review) (11/09), [nova experiência de revisão](https://github.blog/changelog/2026-09-18-copilot-code-review-an-improved-review-experience) (18/09).
- [Responsible use of Copilot agents](https://docs.github.com/en/copilot/responsible-use/agents): "supplement human reviews, not replace them".

## Dados, segurança e licença

- [Managing Copilot policies as an individual subscriber](https://docs.github.com/en/copilot/how-tos/manage-your-account/manage-policies): uso dos dados para treinamento desde 24/04/2026 nos planos individuais (opt-out em Settings → Copilot); filtro "Suggestions matching public code".
- [AI model hosting](https://docs.github.com/en/copilot/reference/ai-models/model-hosting): retenção zero na maioria dos modelos; exceção dos Claude Fable 5 e 5.1 (até 30 dias, classificadores de segurança).
- [GitHub Copilot Product Specific Terms](https://github.com/customer-terms/github-copilot-product-specific-terms): "defense of third party claims" para Business e Enterprise comprados do GitHub. A versão de outubro de 2024 está marcada como substituída em 03/2026; confira a vigente antes de citar em contrato.
- [Content exclusions generally available in Copilot app and CLI](https://github.blog/changelog/2026-09-02-content-exclusions-generally-available-in-copilot-app-and-cli) (02/09/2026, Business e Enterprise).
- [Security in VS Code agents](https://code.visualstudio.com/docs/copilot/security): prompt injection por saída de ferramenta, aprovações e sandbox (o raciocínio vale para o app e o CLI).

## Estudos

- [GitHub, 2022](https://github.blog/news-insights/research/research-quantifying-github-copilots-impact-on-developer-productivity-and-happiness/): 95 desenvolvedores, servidor HTTP em JavaScript, 55% mais rápido.
- [GitHub × Accenture, 2024](https://github.blog/news-insights/research/research-quantifying-github-copilots-impact-in-the-enterprise-with-accenture/) e [Does GitHub Copilot improve code quality?](https://github.blog/news-insights/research/does-github-copilot-improve-code-quality-heres-what-the-data-says/) (2024).
- [METR, 10/07/2025](https://metr.org/blog/2025-07-10-early-2025-ai-experienced-os-dev-study/) ([arXiv 2507.09089](https://arxiv.org/abs/2507.09089)): 16 desenvolvedores experientes, 19% mais lentos, acreditavam estar 20% mais rápidos. [Atualização de 24/02/2026](https://metr.org/blog/2026-02-24-uplift-update/): 57 desenvolvedores, resultado inconclusivo.
- [Asleep at the Keyboard?](https://arxiv.org/abs/2108.09293) (Pearce et al., 2021) e [Schreiber & Tippe, 2025](https://arxiv.org/abs/2510.26103): vulnerabilidades em código gerado.

## Editores (para as perguntas)

- [Copilot in VS Code: features cheat sheet](https://code.visualstudio.com/docs/copilot/reference/copilot-vscode-features), [Agent harnesses](https://code.visualstudio.com/docs/agents/run/agent-harnesses) e [Custom agents](https://code.visualstudio.com/docs/copilot/customization/custom-agents) (`.chatmode.md` virou `.agent.md`).
- [Visual Studio: specialized agents](https://learn.microsoft.com/visualstudio/ide/copilot-specialized-agents?view=visualstudio) e [agent skills](https://learn.microsoft.com/visualstudio/ide/copilot-agent-skills?view=visualstudio).
