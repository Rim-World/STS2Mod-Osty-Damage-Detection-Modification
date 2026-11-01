# DOCS 索引

本目录沉淀可复用的知识与报告。命名规则：`<编号>-<类型>-<中文标题>.md`，编号从 001 递增、三位；类型 T = 任务知识，R = 用户要求的报告，E = 关键证据陈列。

| 编号 | 文档 | 类型 | 说明 |
|---|---|---|---|
| 001 | [奥斯提受击判定机制调研](001-T-奥斯提受击判定机制调研.md) | T | `DieForYouPower` 吸收链路、`SuckPower` / `ImbalancedPower` 的误判根因、107/110/111 三版本比对、`WasFullyBlocked` 影响面评估、三条候选修复路线（结论推荐路线 C） |

## 相关上下文

- 解包源码参考：调研阶段比对过 107、110、111 三个版本的反编译产物，均为本地临时工作目录中的副本，**未纳入本仓库，现已不存在**；三版本目标代码逐字一致的结论记录在 `001-T-奥斯提受击判定机制调研.md` 内。
- 本项目源码：`9.SRC\OstyDamageDetectionMod\`（`ModEntry` + 2 个补丁 + `PowerModelExtensions`）；构建脚本 `9.SRC\OstyDamageDetectionMod\build.ps1`（`dotnet build` + Godot `--import` / `--export-pack` + 拷贝产物，图标源 `9.SRC\OstyDamageDetectionMod\OstyDamageDetectionMod\mod_image.png`）。
- 游戏侧已安装产物：`C:\Game\Steam\steamapps\common\Slay the Spire 2\mods\OstyDamageDetectionMod\`。
- 补丁日志关键词：`OstyDamageDetectionMod: applied 2/2 patches`，日志文件位于 `%APPDATA%\Godot\app_userdata\sts2\logs\godot*.log`。
- 玩家说明文档：`description\奥斯提受击_中文.md`、`description\奥斯提受击_英文.md`。
- mod 列表图标加载逻辑：`NModInfoContainer.Fill`（111 版反编译源码 `MegaCrit.Sts2.Core.Nodes.Screens.ModdingScreen\NModInfoContainer.cs:87`）——游戏从 pck 内 `res://<mod_id>/mod_image.png` 读取图标，manifest 无图标字段，缺失则该处显示为空。
