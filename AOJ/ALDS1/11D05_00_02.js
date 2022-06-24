// https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_11_D
function main(){
  const p = [];
  const r = [];
  function find(i){ return p[i] === i ? i : p[i] = find(p[i]); }
  function same(i, j){ return find(i) === find(j); }

  const n = scan();
  for (let i=0; i<n; i++) {
    p[i] = i;
    r[i] = 0;
  }
  const m = scan();
  for (let i=0; i<m; i++) {
    const j = scan();
    const k = scan();
    const a = find(j);
    const b = find(k);

    if(a === b){ continue; }
    if(r[a] > r[b]){ p[b] = a; }
    else{
      p[a] = b;
      if(r[a] === r[b]){ ++r[b]; }
    }
  }
  const q = scan();
  const ans = [];
  for (let i=0; i<q; i++) {
    const j = scan();
    const k = scan();
    ans.push(same(j,k) ? 'yes' : 'no');
  }
  return ans;
}

process.stdin.resume();
process.stdin.setEncoding('utf8');

let input = '';
let input_index = 0;

function scan(type){
  if(type === 'string'){ return input[input_index++]; }
  else{ return +input[input_index++]; }
}

process.stdin.on('data', function(chunk){
  input += chunk;
});
process.stdin.on('end', function(){
  input = input.trim().split(/\s+/);
  main().forEach(e => console.log(e));
});
