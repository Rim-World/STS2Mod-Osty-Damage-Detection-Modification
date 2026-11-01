# 输出产物索引（10.OUTPUT）

本目录存放构建产物、发布包与备份，内容不入库（`.gitignore` 只放行本文件）。子目录约定：`01-构建产物/`、`02-发布包/`、`03-备份/`。

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-11-01 19:51 | `02-发布包/OstyDamageDetectionMod.v1.0.zip` | 1.0 | 284419 B（278 KB） | 运行包。取自游戏 `mods\OstyDamageDetectionMod\`，含 dll（13312 B）、json（664 B）、pck（269392 B）、pdb（14216 B）；已排除以 `.` 开头的目录（`.sts2-workshop-uploader`） |
| 2026-11-01 19:51 | `02-发布包/OstyDamageDetectionModSourceCode.zip` | 1.0 | 158127 B（155 KB） | 源码包。取自 `9.SRC\OstyDamageDetectionMod\`，共 17 个文件；已排除 `.godot/`、`bin/`、`obj/`、`*.dll`、`*.pck`、`*.pdb`，内含工程 README（中英） |

## 说明

- `01-构建产物/`：当前为空。实际构建输出由 `9.SRC\OstyDamageDetectionMod\build.ps1` 直接写入游戏 `mods\OstyDamageDetectionMod\` 与源码目录下的 `.godot\mono\temp\bin\Debug\`，未在本目录留存副本。
- `03-备份/`：当前为空。
- 两个发布包的内容与游戏内已安装构建一致（2026-08-15 19:00 产物），本次仅做打包，未重新编译。
- 产物不入库，需要重新生成时用 `TMP\02-缓存与临时\make-release-zips.ps1`（该脚本为一次性打包脚本，未放入 `TOOLS/`）。
