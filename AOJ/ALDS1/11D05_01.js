// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/1727342/hipokaba/JavaScript
var n, m, q;
var p = [];
var r = [];

function init(){
  rep(n, function(i){
    p[i] = i;
    r[i] = 0;
  });
}

function find(i){
  return p[i] === i ? i : p[i] = find(p[i]);
}

function same(i, j){
  return find(i) === find(j);
}

function unite(i, j){
  var a = find(i);
  var b = find(j);

  if(a === b){
    return;
  }

  if(r[a] > r[b]){
    p[b] = a;
  }
  else{
    p[a] = b;
    if(r[a] === r[b]){
      ++r[b];
    }
  }
}

function main(){
  n = scan();
  init();
  m = scan();
  rep(m, function(i){
    unite(scan(), scan());
  });
  q = scan();
  rep(q, function(i){
    print(same(scan(), scan()) ? 'yes' : 'no');
  });
}

function rep(a, b, c){
  if(c === undefined){
    c = b;
    b = a;
    a = 0;
  }
  for(var i = a; i < b; ++i){
    if(c(i) === false){
      break;
    }
  }
}

process.stdin.resume();
process.stdin.setEncoding('utf8');

var input = '';
var input_index = 0;

function scan(type){
  if(type === 'string'){
    return input[input_index++];
  }
  else{
    return +input[input_index++];
  }
}

function print(val){
  console.log(val);
}

process.stdin.on('data', function(chunk){
  input += chunk;
});
process.stdin.on('end', function(){
  input = input.trim().split(/\s+/);
  main();
});
