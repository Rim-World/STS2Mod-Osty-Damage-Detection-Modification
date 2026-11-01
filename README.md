# STS2Mod：修改奥斯提受击判定（OstyDamageDetectionMod）

修正《杀戮尖塔 2》中「奥斯提（Osty）替玩家吸收伤害时被判定为玩家掉血」的问题：宠物完全吸收攻击时，化石追踪者不再吸取加力、盛碗虫（石）正确失衡晕眩；宠物被击穿、玩家真实掉血时，两个怪物维持原版行为。

A Slay the Spire 2 mod that fixes hit detection for Osty, the Necrobinder's pet: when Osty fully absorbs an attack, the Fossil Stalker no longer drains Strength and the Bowlbug (Rock) properly becomes off-balance; when Osty is overwhelmed and the player takes real damage, both monsters behave exactly as in the base game.

- 当前版本：**1.0**
- ModId：`OstyDamageDetectionMod`
- 开源地址：<https://github.com/Rim-World/STS2Mod-Osty-Damage-Detection-Modification>

## 功能

亡灵契约师的宠物奥斯提通过 `DieForYouPower` 替玩家承受未格挡伤害。部分怪物的「受击判定」把奥斯提受伤误当成玩家掉血，本 mod 纠正这一判定：

- 攻击被奥斯提完全吸收（玩家未掉血）时，化石追踪者（Fossil Stalker）不再吸取加力；
- 攻击被奥斯提完全吸收（玩家未掉血）时，盛碗虫·岩石变体（Bowlbug Rock）正确触发失衡，下回合晕眩；
- 奥斯提被击穿、玩家真实掉血时，两个怪物保持原版行为（照常加力 / 不晕眩）；
- 未召唤奥斯提时，两个怪物的行为与原版完全一致。

实现上只改两个通用机制 Power（吸取判定、失衡判定），不改任何怪物类、卡牌与数值，对存档无影响，关闭 mod 即恢复原状。未来复用相同机制的新怪物会自动沿用修正后的判定；自行设计新机制的怪物需要另外适配。

## 兼容性

| 项目 | 说明 |
|---|---|
| 游戏版本 | default 107、public beta 111（目标方法在 107 / 110 / 111 中一致） |
| Mod 依赖 | 无（`dependencies: []`） |
| 玩法影响 | 有（清单 `affects_gameplay: true`） |
| 本地化 | 无文本内容，所有语言版本的游戏表现一致 |

游戏启动时会检测两个目标机制是否存在；未来版本若改动了相关机制导致找不到，mod 自动跳过对应部分并只记录日志，不报错、不崩溃，因此清单不设 `min_game_version`。

不保证与盗版、修改版、移动版、老旧版本或冷门 mod、次级 mod 的兼容性。

## 安装

1. 解压发布包，得到 `OstyDamageDetectionMod` 文件夹，内含 `OstyDamageDetectionMod.dll`、`OstyDamageDetectionMod.pdb`、`OstyDamageDetectionMod.json`、`OstyDamageDetectionMod.pck`。
2. 把整个文件夹放进游戏目录的 `mods\` 下：
   `C:\Game\Steam\steamapps\common\Slay the Spire 2\mods\OstyDamageDetectionMod\`（其他平台对应各自的游戏安装目录）。
3. 启动游戏，mod 列表中出现「奥斯提受击判定修改」并显示图标即为生效。
4. 日志确认：`%APPDATA%\Godot\app_userdata\sts2\logs\godot*.log` 中出现 `OstyDamageDetectionMod: applied 2/2 patches`。

## 构建

需要 .NET SDK（`net9.0`）与 Godot .NET 版 4.5.1，并已安装《杀戮尖塔 2》。

```powershell
cd 9.SRC\OstyDamageDetectionMod
.\build.ps1
```

脚本依次执行：

1. `dotnet build`：产物输出到 `.godot\mono\temp\bin\Debug\`；
2. `Godot --headless --import`：生成 `.import` / `.ctex` 资源元数据；
3. `Godot --headless --export-pack "Windows Desktop"`：生成 `OstyDamageDetectionMod.pck`（仅含 mod 列表图标）；
4. 把 dll / pdb / json 拷贝到游戏 `mods\OstyDamageDetectionMod`。

工程引用的 `sts2.dll`、`0Harmony.dll` 从游戏 `data_sts2_windows_x86_64\` 读取，`build.ps1` 中的游戏目录与 Godot 路径为本机绝对路径，换机器需修改。

## 目录结构

```
STS2Mod-修改奥斯提受击判定/
├── AGENTS.md              # 工作区规则
├── README.md              # 本文件
├── CHANGELOG.md           # 单文件更新日志（Keep a Changelog）
├── LICENSE                # MIT
├── .gitignore
├── 1.ADR/                 # 决策记录，ADR.md 为索引
├── 2.PLANS/               # 施工计划，PLANS.md 为索引
├── 3.DOCS/                # 知识与报告，DOCS.md 为索引
├── 4.SDD/                 # 软件设计文档，SDD.md 为索引
├── 5.ChangeLog/           # 分版本日志，ChangeLog.md 为索引
├── 9.SRC/                 # 源码（OstyDamageDetectionMod/，含其工程 README）
├── 10.OUTPUT/             # 构建产物与发布包，output.md 为索引
├── PRIVACY/               # 机密信息位，PRIVACY.md 为索引
├── TMP/                   # 临时与过程文件，TMP.md 为索引
├── TOOLS/                 # 工具与自写脚本，TOOLS.md 为索引
├── description/           # 创意工坊文案（中英）
└── pics/                  # 封面与配图
```

## 文档索引

| 目录 | 索引 | 内容 |
|---|---|---|
| `1.ADR/` | [ADR.md](1.ADR/ADR.md) | 路线选型、构建与安装、图标与 pck 打包三项决策 |
| `2.PLANS/` | [PLANS.md](2.PLANS/PLANS.md) | 总的修复计划与施工记录 |
| `3.DOCS/` | [DOCS.md](3.DOCS/DOCS.md) | 奥斯提受击判定机制的调研笔记 |
| `4.SDD/` | [SDD.md](4.SDD/SDD.md) | 总体设计（模块划分、补丁策略、数据流、异常与兼容设计） |
| `5.ChangeLog/` | [ChangeLog.md](5.ChangeLog/ChangeLog.md) | 1.0 的完整版本记录 |
| `10.OUTPUT/` | [output.md](10.OUTPUT/output.md) | 本地构建产物与发布包登记 |

面向玩家的说明文档在 `description/`（中文、英文各一份），源码内另有一份英文 / 中文 README：`9.SRC/OstyDamageDetectionMod/README.md` 与 `README.zh.md`。

## 版本

当前版本 **1.0**（2026-08-15 构建安装）。版本沿革见 [CHANGELOG.md](CHANGELOG.md)。

已知问题：实机验证项（启动日志补丁计数、mod 列表图标、场景 A / B、无奥斯提回归）尚未全部完成。

## 致谢

- 本 mod 使用 opencode（桌面版）+ DeepSeek V4 Flash（0731，GA）完成，感谢梁圣。
- 感谢《杀戮尖塔 2》制作组为方便玩家制作 mod 所做的努力。

## 开源

MIT 许可，见 [LICENSE](LICENSE)。

仓库地址：<https://github.com/Rim-World/STS2Mod-Osty-Damage-Detection-Modification>
