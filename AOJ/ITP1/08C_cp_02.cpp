// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/749566/ei1333/C++
#include<iostream>
#include<string>
#include<cstdio>
using namespace std;
int main(){
  string str;
  int alp[26]={};
  while(getline(cin,str)){
    for(int i=0,l=str.size();i<l;i++){
      if(str[i]>='a'&&str[i]<='z') alp[str[i]-'a']++;
      else  if(str[i]>='A'&&str[i]<='Z') alp[str[i]-'A']++;
    }
  }
  for(int i=0;i<26;i++){
    printf("%c : %d\n",i+'a',alp[i]);
  }
}
