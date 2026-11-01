# ADR-003：mod 图标与 pck 打包

- 日期：2026-08-15
- 状态：**已实施**

## 决策

1. **版本号 1.0、作者「再玩小卡组找人弄你」**：manifest 中已按用户指定（与用户定稿文案一致，ADR-002 确认）。
2. **mod 图标**：`pics\Osty_small.png` → `9.SRC\OstyDamageDetectionMod\OstyDamageDetectionMod\mod_image.png`。
   - 依据：反编译 `NModInfoContainer.Fill`（decompiled-111，NModInfoContainer.cs:87）——游戏从 **pck 内 `res://<mod_id>/mod_image.png`** 读取列表图标，manifest 无 icon 字段；缺失时显示空。
3. **manifest `has_pck: true`**（原 false）：图标必须打进 pck 才能被 `ResourceLoader.Exists` 找到。
4. **构建恢复 pck 步骤**：新增 `project.godot`（config/icon 指向 mod_image.png）与 `export_presets.cfg`（export_files 仅含 mod_image.png，resources 过滤），build.ps1 恢复 Godot `--import` + `--export-pack`（参考 PhantomKillerMod 正式版 v1.0）。

## 实施记录

- 构建：0 警告 0 错误；Godot import 生成 `.import`/`.ctex`，export-pack 打包成功。
- 安装产物：`OstyDamageDetectionMod.dll`（13312 B）、`.pdb`、`.json`（664 B，has_pck true）、`OstyDamageDetectionMod.pck`（269392 B，含 res://OstyDamageDetectionMod/mod_image.png）。
- 说明文档：`description\奥斯提受击_中文.md`（仿 ①环境 ②语言 ③效果 ④影响 ⑤兼容性 ⑥鸣谢 ⑦开源地址 结构）。

## 待验证

- 游戏 mod 列表界面显示 Osty 图标（`res://OstyDamageDetectionMod/mod_image.png`）。