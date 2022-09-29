// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_D/review/1778317/dohatsu/C++
#include<iostream>
using namespace std;

int Rank[1000005];
int Tmp[1000005];
int kc,len;

bool compare_sa(int i,int j){
  return
    Rank[i]!=Rank[j]?
    Rank[i]<Rank[j]:
    (i+kc<=len?Rank[i+kc]:-1)<(j+kc<=len?Rank[j+kc]:-1);
}

void construct_sa(char* S,int *sa){
  len=strlen(S);
  for(int i=0;i<=len;i++){
    sa[i]=i;
    Rank[i]=i<len?S[i]:-1;
  }
  for(kc=1;kc<=len;kc*=2){
    sort(sa,sa+len+1,compare_sa);
    Tmp[sa[0]]=0;
    for(int i=1;i<=len;i++){
      Tmp[sa[i]]=Tmp[sa[i-1]]+compare_sa(sa[i-1],sa[i]);
    }
    for(int i=0;i<=len;i++)Rank[i]=Tmp[i];
  }
}


int n,m;
char str[1000005];
char t[1000005];
int sa[1000005];

int main(){
  scanf("%s",str);
  n=strlen(str);
  construct_sa(str,sa);
  scanf("%d",&m);
  while(m--){
    scanf("%s",t);
    int k=strlen(t);
    int l=0,r=n+1,m;
    while(l+1<r){
      m=(l+r)/2;
      if(strncmp(str+sa[m],t,k)<=0)l=m;
      else r=m;
    }
    printf("%d\n",(strncmp(str+sa[l],t,k)==0));
  }
  return 0;
}
