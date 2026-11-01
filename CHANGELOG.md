# 更新日志

本文件遵循 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.1.0/) 规范，版本号遵循 [语义化版本](https://semver.org/lang/zh-CN/)。

## 未发布

### 变更

- 仓库整理为 AGENTS 规定的十目录结构：`adr/` → `1.ADR/`，`plans/` → `2.PLANS/`，`docs/` → `3.DOCS/`，`src/` → `9.SRC/`。
- 新增 `4.SDD/`（总体设计）、`5.ChangeLog/`（分版本日志）、`10.OUTPUT/`、`PRIVACY/`、`TMP/`、`TOOLS/` 目录与索引。
- 补全根 `README.md`（Standard-Readme 结构）、`CHANGELOG.md`、根 `.gitignore`。

### 说明

- 本次整理只移动与重命名文件、补写文档，未改动任何 `.cs` / `.csproj` / `project.godot` / `export_presets.cfg` / `build.ps1` / mod 清单内容，构建产物与行为不变。

## [1.0] - 2026-08-15

### 新增

- 首个版本。新增独立 mod `OstyDamageDetectionMod`，修正「奥斯提（Osty）吸收伤害被判定为玩家掉血」的问题。
- 补丁 `SuckPower.AfterAttack`：攻击被奥斯提完全吸收时，化石追踪者（Fossil Stalker）不再吸取加力；奥斯提被击穿、玩家真实掉血时照常加力。
- 补丁 `ImbalancedPower.AfterDamageGiven`：攻击被奥斯提完全吸收时，盛碗虫·岩石变体（Bowlbug Rock）触发失衡并在下回合晕眩；被击穿时继续进攻。
- mod 列表图标 `res://OstyDamageDetectionMod/mod_image.png`，清单相应改为 `has_pck: true` 并随构建生成 pck。

### 兼容性

- 支持 default 107、public beta 111（目标方法在 107 / 110 / 111 中一致）。
- 无 mod 依赖；纯逻辑修改，不改怪物、卡牌与数值，对存档无影响，关闭 mod 即恢复原状。

### 已知问题

- 实机验证尚未完成：启动日志补丁计数、mod 列表图标、场景 A / B、无奥斯提回归均待验证。
