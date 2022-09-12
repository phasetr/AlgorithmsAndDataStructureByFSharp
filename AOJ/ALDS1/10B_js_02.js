// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/4993987/coolgk/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
const lines = input.split('\n');
lines.shift();

const nums = lines.reduce((result, line, index) => {
    const [row, col] = line.split(' ').map((n) => Number(n));
    return index === 0 ? result.concat(row, col) : result.concat(col);
}, []);

function dp(nums) {
  const dp = Array(nums.length)
    .fill(0)
    .map(() => Array(nums.length).fill(0));

  for (let start = nums.length - 1; start >= 0; start--) {
    for (let end = start + 2; end < nums.length; end++) {
      dp[start][end] = Infinity;
      for (let i = start + 1; i < end; i++) {
        dp[start][end] = Math.min(dp[start][end], dp[start][i] + dp[i][end] + nums[i] * nums[start] * nums[end]);
      }
    }
  }

  return dp[0][nums.length - 1];
}

console.log(dp(nums));
