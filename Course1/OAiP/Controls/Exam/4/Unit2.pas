unit Unit2;

interface
type
rec = record
   key: word;
   f: integer;
end;

mas = array[1..14] of rec;


TClass = class(TObject)
      procedure qsort(var a:mas;l,r:integer);
end;

implementation

procedure TClass.qsort(var a:mas;l,r:integer);
var
 i,j,s:word;
 t: rec;
begin
s:= a[(l+r) div 2].key;
i:=l;
j:=r;
while i<=j do
 begin
  while a[i].key<s do inc(i);
  while a[j].key>s do dec(j);
  if i<=j then
   begin
    t:=a[i];
    a[i]:=a[j];
    a[j]:=t;
    inc(i);
    dec(j);
   end;
 end;
if i<r then qsort(a,i,r);
if j>l then qsort(a,l,j);
end;


end.
