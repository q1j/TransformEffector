# TransformEffector

## できること

このスクリプトは、ハンドルの操作（拡大縮小／回転／移動）を、ターゲットのTransformに反映するスクリプトです。

ターゲットにモデルのボーンを設定することで、モーションに変化を付けることが出来ます。

UnityのGameObjectに Add Copmonet して使用します。

## 用語

「ユーザーが操作するGameObject」をハンドル、「ハンドルの影響を受けて動くGameObject」をターゲットと呼びます。

「ハンドルを操作」→「ターゲットが動く」という関係です。

## 適用例

![移動、拡大、回転](https://github.com/q1j/TransformEffector/blob/images/3effecf.gif)

## コンポーネント's

### TransformEffecterコンポーネント

本スクリプトのメインコンポーネントです。

必須。

#### プロパティ

| パラメータ名 | 設定する内容 |
|:-:|:-:|
| Size | 設定するターゲットの数 |
| Element - TR | ターゲットのTransformを指定 |
| Element - Scale Weight | 拡大／縮小の重み（ウェイト） |
| Element - Rotaion Weight | 回転の重み（ウェイト） |
| Element - Position Weight | 移動の重み（ウェイト） |
 
各ウェイトは 0～1 で指定します。

0 は無効、1 はハンドルの動きがそのまま適用されます。

### Effectコンポーネント
ハンドルに加えたTransformの変化を、ターゲットに反映します。

| 反映する動き | コンポーネント名 | 
|:-:|:-:|
| 拡大／縮小(scale) | ScaleEffect | 
| 回転(Rotation)| RotationEffect |
| 移動(Position)| PositionEffect |

#### プロパティ

| プロパティ名 | 反映する動き |
|:-:|:-:|
| Keep Length | 辺の合計の長さを保つ |

ScaleEffectのみ設定可能です。

ハンドルの変形をターゲットに反映する際、ターゲットの辺の合計の長さを保つ様に努力します。

### Recoilコンポーネント

ハンドルが初期位置に戻る動きを付けます。

ハンドルに戻ることで（Effectコンポーネントの効果で）ターゲットにも戻る動きが付きます。

#### プロパティ

| プロパティ名 | 反映する動き |
|:-:|:-:|
| weight | 反動の重さ |
| Friction | 揺り戻し |　

Friction(揺り戻し)は ScaleRecoil と PositionRecoil のみ設定可能です。

weight と Friction、どちらかまたは両方が　0　の場合、無効になります。

## 設定例

モーション中の馬のモデルに干渉してみます。

モデルはUnityのAssetStoreの『Animated Horse』というアセットをお借りしました。

Animated Horse:
https://www.assetstore.unity3d.com/jp/#!/content/16687

### ハンドルを設置

ハンドルとなるGameObjectを、Hierarchyの「Horse」ツリーの配下に置きます。

![ハンドルをhierarcyに設置](https://github.com/q1j/TransformEffector/blob/images/handle_in_hierarchy_.PNG)

ここではモデルの横に配置しておきますが、Scene上のどこでも構いません。

![ハンドルをsceneに設置](https://github.com/q1j/TransformEffector/blob/images/handle_in_scene.PNG)

### コンポーネントをAdd

ハンドルにコンポーネントをAddします。

![コンポーネントの設定](https://github.com/q1j/TransformEffector/blob/images/handle_inspector.PNG)

Size に ターゲットの数を決めて、TRにターゲットのTransformを、各Weight にハンドルの動きを伝える重みを設定します。

![targetの設定](https://github.com/q1j/TransformEffector/blob/images/transform_effector.PNG)

設定が出来たら、実行(play)して、ハンドルを動かす（拡大縮小／回転／移動）ことで、ターゲットを操作することが出来ます。

## 補足

### 使わない機能のコンポーネントはAdd不要

例えば、拡大縮小を行わない場合は「ScaleEffect と ScaleRecoil のコンポーネントは不要」、回転を自動で戻さない場合は「RotationRecoilコンポーネントは不要」です。

### 機能の有効／無効はWeight値で

ゲーム開始時に Disable となっているコンポーネントは、実行中に Enable にしても機能が有効にはなりません。

ゲーム中に有効／無効の切り替えを行いたい場合、ターゲットの Weight を操作して下さい。

0 にすることで無効、それ以外で有効になります。

## 動作環境
Unity 2017.3.0f3 (64bit) にて動作確認をしています。
