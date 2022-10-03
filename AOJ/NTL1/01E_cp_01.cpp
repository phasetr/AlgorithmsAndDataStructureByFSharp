// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/848746/s1210207/C++
#include <iostream>
using namespace std;

void extgcd(int a,int b,int &x,int &y){
  x = 1; y = 0;
  if(b != 0) extgcd(b, a% b, y, x), y -= (a / b) * x;
}

int main(){
  int a,b,x,y;

  cin >> a >> b;
  extgcd(a,b,x,y);
  cout << x << " " << y << endl;

  return 0;
}
