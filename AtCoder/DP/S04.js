// https://atcoder.jp/contests/dp/submissions/3946655
var GET=(function(){function f(s){return new g(s);}function g(s){this._s=s.trim().split("\n");this._y=0;}g.prototype.a=function(f){var s=this._s, y=this._y, r;if(typeof s[y]==="string")s[y]=s[y].split(" ").reverse();r=s[y].pop();if(!s[y].length)this._y++;return f?r:+r;};g.prototype.l=function(f){var s=this._s[this._y++].split(" ");return f?s:s.map(a=>+a);};g.prototype.m=function(n,f){var r=this._s.slice(this._y,this._y+=n).map(a=>a.split(" "));return f?r:r.map(a=>a.map(a=>+a));};g.prototype.r=function(n,f){var r=this._s.slice(this._y,this._y+=n);return f?r:r.map(a=>+a);};return f;})();
var o=GET(require("fs").readFileSync("/dev/stdin","utf8"));
var mod = 1e9+7;

console.log(main());
function main(){
  var k = o.a(1);
  var d = o.a();
  var dp = Array(d).fill(0).map(a=>Array(2).fill(0));
  dp[0][0] = 1;
  for(var i = 0; i < k.length; i++){
    var dp2 = Array(d).fill(0).map(a=>Array(2).fill(0));
    for(var j = 0; j < d; j++){
      for(var x = 0; x < k[i]; x++){
        var d2 = ((j-x)%d+d)%d;
        dp2[j][1] += dp[d2][0] + dp[d2][1];
      }
      var d2 = ((j-k[i])%d+d)%d;
      dp2[j][0] += dp[d2][0];
      dp2[j][1] += dp[d2][1];
      for(x = +k[i] + 1; x < 10; x++){
        var d2 = ((j-x)%d+d)%d;
        dp2[j][1] += dp[d2][1];
      }
    }
    dp = dp2.map(a=>a.map(a=>a%mod));
  }
  return (dp[0][0] + dp[0][1] + mod - 1) % mod;
}
