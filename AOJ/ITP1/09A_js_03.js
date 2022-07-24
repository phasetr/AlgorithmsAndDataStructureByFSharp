// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/5067545/cotta0322/JavaScript
function main(args) {
  const input = args.toLowerCase().split('\n');
  const W = input[0];
  input.pop();
  input.shift();
  console.log(input.join('\n').split(/ |\n/).filter((v) => v == W).length);
}
main(require('fs').readFileSync('/dev/stdin', 'utf8').trim());
