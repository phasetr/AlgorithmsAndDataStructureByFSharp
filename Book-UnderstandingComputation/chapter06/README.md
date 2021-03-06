6章 無からのプログラミング
=======================

この章では形なしラムダ計算(untyped lambda calculus)について調べる。
今までは機械のモデルから計算をとらえようとしてきたが、こちらはプログラミング言語の一種として計算をとらえようとする試みになる。

6.1 ラムダ計算をまねる
-----------------------

ラムダ計算は非常に限られた機能しか持たないプログラミング言語で表現できる。ここでは今までと同じくRubyを用いて、ただし非常に限られた言語機能しか使わずに、ラムダ計算をまねることにする。

- 変数の参照
- procの生成
- procの呼び出し

### Procについて

RubyのProcについてまとめておく。

そもそもRubyにはブロックと呼ばれる、複文自体をまとめた概念がある。
`do ~ end` もしくは `{ ~ }` で囲まれた部分はすべてブロックである。

ブロックは特殊で、メソッドの引数としてしか存在できない。このブロックをオブジェクト化したらProcになる。
ちなみに`lambda`もProcの一種であり、似たような概念である。クロージャとしての機能も持っていて、外部の変数を束縛することができる。

[[Ruby] ブロックとProcをちゃんと理解する - Qiita](http://qiita.com/kidach1/items/15cfee9ec66804c3afd2)

```ruby
# Procの生成にはいくつか書き方がある
myproc = Proc.new {|x| x + 5}
myproc = proc {|x| x + 5}
myproc = lambda {|x| x + 5}
myproc = -> x { x + 5 }

p myproc.call(5) #10
p myproc.call(0) #5

# Procの呼び出しは.call以外にも書き方がある

p myproc[10] #15
p myproc.(12) #17
```

今回の教科書では、 `-> x { x }` 形式の宣言と、 `myproc[10]` 形式の呼び出しを使っている。

### FizzBuzzをラムダ計算で書く

```ruby
(1..100).each do |n|
  if (n % 15).zero?
    puts 'FizzBuzz'
  elsif (n % 3).zero?
    puts 'Fizz'
  elsif (n % 5).zero?
    puts 'Buzz'
  else
    puts n.to_s
  end
end
```

これをラムダ計算にひたすら翻訳する、という作業をしてみる。putsはI/Oを伴ってしまうので、簡単のために省くことにする。

```ruby
(1..100).map do |n|
  if (n % 15).zero?
    'FizzBuzz'
  elsif (n % 3).zero?
    'Fizz'
  elsif (n % 5).zero?
    'Buzz'
  else
    n.to_s
  end
end
```

ここから、動かないコードに置き換えながら進めるので、プログラムは分割して書いていくことにする。


### 6.1.3 数

まずは自然数を定義する。
ラムダ計算ではProcの生成と呼び出ししか行えない。ので、 **あるprocをn回呼び出す** というprocを定義し、それぞれをnという数字に相当するものとして扱う。
これはチャーチエンコーディングと呼ばれており、定義された自然数をチャーチ数と言う。

- [number.rb](number.rb) を参照。

### 6.1.4 ブール値

`true`と`false`は2つの選択肢を引数として渡し、1番目と2番目の選択肢のどちらかを選ぶコードとして実装する。

- [bool.rb](bool.rb)を参照。

### 6.1.5 述語

`Fixnum#zero?`をprocベースにしたものを実装する。

- [is_zero.rb](is_zero.rb)を参照。

### 6.1.6 ペア

配列を作るための要素として、二つの値を保持するpairという概念を追加する。

- [pair.rb](pair.rb)を参照。

### 6.1.7 数値演算

数値演算を各種定義する。

- [calc.rb](calc.rb)を参照。

この辺りから、チャーチ数がprocであるという性質を使いまくっている。
ラムダ計算で定義した自然数はそれ自体が「n回ある操作を繰り返す」という関数であるため、関数のように使って色々実装できるわけだ。

### YコンビネータとZコンビネータ

Yコンビネータ(不動点コンビネータ、不動点結合子)とは、高階関数の一種。
与えられた関数の不動点(つまり自分自身)を求めることができる。

簡単に言えば、procを引数にしてYを呼び出すとprop[proc]という呼び出しを行う。

これによって名前を使わなくても無名関数で再帰を行うことができるようになる。

```ruby
Y = -> f { -> x { f[x[x]] }[-> x { f[x[x]] }] }
```

遅延戦略が値渡しのRubyのような言語では、Yコンビネータは無限ループに陥ってしまってうまく動かない。
これをクロージャやProcなどを用いて遅延評価に修正したものがZコンビネータである。

```ruby
Z = -> f { -> x { f[-> y { x[x][y] }] }[-> x { f[-> y { x[x][y] }] }] }
```

ちなみにJavaScriptだとこんな感じになるらしい。(Wikipediaより)

```javascript
function Z(f) {
    return (function(x) {
        return f(function(y){
            return x(x)(y);
        });
    })(function(x){
        return f(function(y){
            return x(x)(y);
        });
    });
}
```
