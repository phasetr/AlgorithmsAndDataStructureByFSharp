// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/800792/ei1333/C++
#include<string>
#include<iostream>
#include<algorithm>
#include<set>
using namespace std;
int main(){
  std::ios_base::sync_with_stdio(false);
  set<string> st;
  int n;
  cin >> n;
  while(n--){
    string BUFF,c;
    cin >> BUFF >> c;
    if(BUFF=="insert") st.insert(c);
    else cout << (st.find(c)!=st.end()?"yes":"no") << endl;
  }
}
