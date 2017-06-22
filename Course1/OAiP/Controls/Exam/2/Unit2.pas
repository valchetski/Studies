unit Unit2;

interface

type
rec = record
 k:word;
 i:word;
end;

mas = array [1..15] of rec;

TClass = class(TObject)
  arr:mas;
  constructor Create(a:mas);
  function Find(k,p,q:word):word;
end;

implementation

constructor TClass.Create(a:mas);
begin
 arr:=a;
end;

function TClass.Find(k,p,q:word):word;
var
 i:word;

 function Del(p,q:word):word;
 var
  m:word;
 begin
  if p=q then Del:=p
          else
           begin
            m:=(p+q)div 2;
            if arr[m].k<k then Del:=Del(m+1,q)
                        else Del:=Del(p,m);
           end;
 end;



begin
 i:= Del(p,q);
 if arr[i].k = k then result:=arr[i].i
  else result:=0;
end;

end.
