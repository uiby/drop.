# drop.
ゲーム説明文 : 生成した魂を転生させるゲーム

ゲーム内容文 : 床を動かしてボールを穴に入れるゲーム

うり : ドキドキ感と爽快感の両立(まだ未定)

近いゲーム感覚 : コロコロカービィ

こういうジャンルは操作対象は自機なのがほとんど。一度Leapの操作対象を見直す必要あり。

以下未実装部分の列挙。重要度の高い項目を処理していく

## Title

- [ ] タイトル名の決定(落ち魂よりビビッと来たのがあったらそれにする)  [重要度 : 中]
- [ ] タイトルロゴ(テキストではなくイメージに)  [重要度 : 高]
- [ ] 背景  [重要度 : 中]
- [x] 生成魂の演出(現状では光ってるだけなので魂っぽくさせる)  [重要度 : 高]
- [ ] メインシーン移行のトリガータイミングの調整  [重要度 : 高]
- [ ] BGM  [重要度 : 低]
- [ ] SE  [重要度 : 中]

---
## First stage

- [x] 説明文の修正(ユーザにさせるのは説明っぽい方にして、文章自体はワクワクさせるような感じに変更)  [重要度 : 高]
- [x] 魂が落ちるタイミングの調整(任意に落とせるようにする)  [重要度 : 高]
- [x] 場外に落ちても生命力は減らない or場外に落とさせない  [重要度 : 高]
- [ ] SE  [重要度 : 高]

---
## Main Game

- [ ] ステージの改善
  - [ ] 全ステージ数の決定  [重要度 : 激高]
  - [ ] 各ステージの形の決定(__雰囲気を統一させる__,ユーザが飽きさせないようにところどころアクション性を混ぜる)  [重要度 :激高]
  - [ ] 各ステージの大きさ(カメラワークに収める)の調整  [重要度 : 激高]
  - [ ] 各ステージのクリアタイムの調整 [重要度 : 激高]
  - [ ] 穴のまわりを少し削る(落ちやすくする)  [重要度 : 高]
  - [ ] 穴の存在を強くする(矢印の表示や色を変える等)  [重要度 : 高]
  - [ ] ステージが壊れる演出の強化  [重要度 : 中]
- [x] ステージクリア評価表の見直し  [重要度 : 高] → Late < Good < Excellent に変更
- [ ] 1つのステージにいられる時間の制限を設ける  [重要度 : 中]
- [x] 生命力アイテムのモデル作成  [重要度 : 高]
- [x] 画面ぶれの実装  [重要度 : 高]
- [ ] 背景(今はただのグラデーションなので、何かプラスになるように変更する)  [重要度 : 中]
- [ ] コネクトシステムの改良  [重要度 : 中]
- [ ] 画面上に手を出現させる(操作性の向上が目的)  [重要度 : 高]
- [ ] 操作方法の改良(早く手を振ったら魂が加・減速する等)  [重要度 : 高]
- [ ] UI部分
  - [ ] バックに背景の設置  [重要度 : 高]
  - [ ] 各項目の配置場所の改善  [重要度 : 低]
- [ ] BGM  [重要度 : 高]
- [ ] SE  [重要度 : 高]

---
## Result

- [ ] キャラクターの改善
  - [x] 全キャラクター数の決定  [重要度 : 激高] → 5,6体
  - [x] キャラクターの決定  [重要度 : 激高] → ミジンコ < テントウムシ < ヒツジ < 王様 < フェニックス < 魔王(満点用)
  - [ ] キャラクターの絵  [重要度 : 高] → ミジンコほど かっこいい:可愛い = 2:8 , フェニックスほど かっこいい:可愛い = 8:2
  - [ ] キャラクターのモーション [重要度 : 中] → 出来れば作る,時間が足りないならScaleをいじる
- [ ] ランキング機能の実装  [重要度 : 低]
- [ ] 各評価の演出の強化  [重要度 : 高]
- [ ] 誕生演出の改善  [重要度 : 中]
- [ ] リトライ,タイトル移行機能の実装  [重要度 : 高]
- [ ] たんじょうの文字をイメージに変更  [重要度 : 低]
- [ ] パーティクルの素材(イラスト)が欲しい  [重要度 : 高]
- [ ] SE  [重要度 : 高]
- [ ] BGM  [重要度 : 中]

---
## Bug
- [ ] 魂と床がすり抜ける  [重要度 : 激高]
- [ ] 床のy軸回転もLeapの操作対象になっている  [重要度 : 激高]
