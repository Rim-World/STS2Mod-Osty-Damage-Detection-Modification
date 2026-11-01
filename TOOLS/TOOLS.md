# 工具与脚本索引（TOOLS）

一级子项只允许工具文件夹、自写脚本文件夹 `scripts/` 与本索引文件。

| 时间 | 工具/脚本 | 用途 | 版本 | 大小 | 来源 | 安装方式/依赖 |
|---|---|---|---|---|---|---|
| — | （无） | 本项目未在仓库内放置工具或自写脚本 | — | — | — | — |

## 说明

- 本 mod 的构建由源码目录内的 `9.SRC/OstyDamageDetectionMod/build.ps1` 完成，该脚本属于工程源码的一部分，因此保留在 `9.SRC/` 内，不搬入本目录。
- 构建依赖的**外部**环境不在仓库内，逐项记录如下：

| 依赖 | 版本 | 用途 | 本机位置 |
|---|---|---|---|
| .NET SDK | 满足 `net9.0` 目标框架（具体补丁版本未记录） | 编译 C# 程序集 | 系统全局安装 |
| Godot（.NET 版） | 4.5.1-stable mono | `--import` 生成资源元数据、`--export-pack` 打包 pck | `C:\Godot&GDRE\Godot_v4.5.1-stable_mono_win64\`（`build.ps1` 内硬编码） |
| Godot.NET.Sdk | 4.5.1 | `OstyDamageDetectionMod.csproj` 的构建 SDK | NuGet 包，随构建还原 |
| 游戏程序集 | 与实机版本一致（107 / 110 / 111） | `sts2.dll`、`0Harmony.dll` 编译期引用 | `C:\Game\Steam\steamapps\common\Slay the Spire 2\data_sts2_windows_x86_64\` |

- `scripts/` 目录目前为空：整理过程中没有产生需要长期保留的一次性脚本。
