// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/1833464/beet/C++
#include<iostream>
#include<string>
using namespace std;
int main(){
  string s,p;
  cin >> s >> p;
  s=s+s;
  if(s.find(p)!=-1) {cout << "Yes" << endl;}
  else {cout << "No" << endl;}
  return 0;
}
