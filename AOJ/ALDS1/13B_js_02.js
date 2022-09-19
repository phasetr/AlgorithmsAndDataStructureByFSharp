// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/6269554/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

function pazzle (str) {
  var obj = {};
  obj[str] = 0;
  var d = [[-1,0],[0,1],[1,0],[0,-1]];
  var v = str.split("").map(Number);
  var q = [[v,0]];
  while (q.length > 0) {
    var a = q.shift();
    var arr = a.shift(),
        count = a.shift();
    var idx = arr.indexOf(0);
    var y = Math.floor(idx/3),
        x = idx%3;
    var m = [arr.slice(0,3), arr.slice(3,6), arr.slice(6,9)];

    for (var i = 0; i < d.length; i++) {
      var ny = y+d[i][0],
          nx = x+d[i][1];
      if (ny < 0 || ny >= 3 || nx < 0 || nx >= 3) continue;
      m[y][x] = m[ny][nx];
      var tmp = m[ny][nx];
      m[ny][nx] = 0;
      var v0 = m[0].concat(m[1],m[2]);
      var s = v0.join("");
      if (s === "123456780") return count+1;
      if (obj.hasOwnProperty(s) === false) {
        obj[s] = count+1;
        q.push([v0,count+1]);
      }
      m[y][x] = 0,
      m[ny][nx] = tmp;
    }
  }
  return 0;
}
var str = (input.trim()).replace(/\n|\s/g,"");
if (str !== "123456780") console.log(pazzle(str));
else console.log(0);
