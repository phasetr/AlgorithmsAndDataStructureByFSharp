// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/749561/ei1333/C++
#include<iostream>
#include<string>
using namespace std;
int main(){
  string str;
  int sum;
  while(cin >> str && str!="0"){
    sum = 0;
    for(int i=0,l=str.size();i<l;i++) sum += str[i]-'0';
    cout << sum << endl;
  }
}
