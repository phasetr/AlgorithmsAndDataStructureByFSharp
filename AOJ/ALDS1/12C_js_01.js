// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/2315885/kyawakyawa/JavaScript
var h = [],hs = 0;
h[0] = new Array(2);
h[0][0] = -1;h[0][1] = -1;

function insert(key){
  h[++hs] = key;
  var i = hs;
  while(h[i][1] < h[Math.floor(i / 2)][1]){
    var ex = h[i];
    h[i] = h[Math.floor(i / 2)];
    h[Math.floor(i / 2)] = ex;
    i = Math.floor(i / 2);
  }
}

function extract(){
  if(hs <= 0) { return; }
  var ret = h[1];
  h[1] = h[hs--];
  i = 1;
  while((i * 2 <= hs && h[i][1] > h[i * 2][1]) || (i * 2 + 1 <= hs && h[i][1] > h[i * 2 + 1][1])){
    var l = i * 2;var r = i * 2;
    if(i * 2 + 1 <= hs)
      r++;
    var m = h[l][1] <= h[r][1] ? l : r;
    var ex = h[i];
    h[i] = h[m];
    h[m] = ex;
    i = m;
  }
  return ret;
}

function Main(input){
  input = input.split("\n");
  var n = parseInt(input[0],10);
  var graph = new Array(n);
  for(var i = 0;i < n;i++){
    input[i + 1] = input[i + 1].split(" ");
    var u = parseInt(input[i + 1][0],10);
    var k = parseInt(input[i + 1][1],10);
    graph[u] = new Array(k);
    for(var j = 0;j < k;j++)
      graph[u][j] = new Array(2);
    for(var j = 0;j < k;j++){
      graph[u][j][0] = parseInt(input[i + 1][j * 2 + 2],10);
      graph[u][j][1] = parseInt(input[i + 1][j * 2 + 3],10);
    }
  }

  var count = 1;
  var sum = Array(n);
  for(var i = 0;i < n;i++)
    sum[i] = 1000000000;
  sum[0] = 0;
  for(var i = 0;i < graph[0].length;i++){
    insert(graph[0][i]);
  }
  while(count < n){
    var aa = extract();
    if(sum[aa[0]] < 1000000000)
      continue;

    sum[aa[0]] = aa[1];
    count++;

    for(var i = 0;i < graph[aa[0]].length;i++){
      graph[aa[0]][i][1] += sum[aa[0]];
      insert(graph[aa[0]][i]);
    }
  }

  for(var i = 0;i < n;i++){
    console.log(i + " " + sum[i]);
  }
}

Main(require("fs").readFileSync("/dev/stdin","utf8"));
