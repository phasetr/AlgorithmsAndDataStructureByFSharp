// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/1835662/beet/C++
#include<iostream>
#include<string>
using namespace std;
int main(){
  string str;
  cin >> str;
  int i;
  int m,b;
  while(str!="-"){
    cin >> m;
    for(i=0;i<m;i++){
      cin >> b;
      str=str.substr(b,str.size()-b)+str.substr(0,b);
    }
    cout << str << endl;
    cin >> str;
  }
}
