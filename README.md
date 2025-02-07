# Biofeedback Framework

バイオフィードバックを活用したVRアプリケーション開発を支援するフレームワークです。このフレームワークは、生体データをリアルタイムで取得・解析し、Unityを用いてVR環境内でのフィードバック処理を容易に行えるように設計されています。

## 概要

本プロジェクトは、バイオフィードバック技術を活用し、Unityを用いたVRアプリケーション開発における技術的なハードルを下げることを目的としています。本フレームワークでは、以下の機能を提供します：

- バイオフィードバックのためのフレームワーク
- データ取得、変換、フィードバック処理の3段階のモジュールを交換可能
- Vive Pro Eyeのセンサーを用いたサンプルモジュール
- オープンソースとして公開し、研究者・開発者間でのモジュール共有を支援

本フレームワークはHTC Vive Pro Eyeを使用し、Unity上で動作します。詳細は[マニュアル](manual.pdf)をご参照ください。

## 動作確認

以下のソフトウェアおよびハードウェアでの動作を確認しています：

- Unity 2019.4.27f1
- HTC Vive Pro Eye
- SteamVR 2.7.3
- VIVE Eye and Facial Tracking SDK 1.3.3.0
- Python 3.11.11（動作テストに使用）

## インストール

1. このリポジトリをクローンします：
   ```bash
   git clone https://github.com/chanpuru7777/Biofeedback-Framework.git


Biofeedback-Framework/ 
├── README.md # プロジェクトの説明（このファイル） 
├── manual.pdf # フレームワークの詳細なマニュアル 
├── src/ # ソースコード 
│ ├── modules/ # 各種モジュール 
│ │ ├── A_EyeOpennessInput.cs 
│ │ ├── B_BlinkAwareness.cs 
│ │ ├── C_LightingFeedback.cs 
│ ├── main.unity # Unityのメインシーン 
├── test/ # 動作テスト関連 
│ ├── test_data/ # テスト用データ 
│ ├── test_scripts/ # Pythonによる動作検証スクリプト 

