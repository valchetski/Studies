unit Unit2;

interface
type
rec = record
   key: word;
   f: integer;
end;

mas = array[1..14] of rec;


TClass = class(TObject)
      procedure sort(var a:mas;n:word);
end;

implementation

procedure TClass.sort(var a:mas;n:word);

procedure Sliv(p,q:word);
var
m,i,j,k:word;
b:mas;
begin
k:=1;
m:=(p+q) div 2;
i:=p;
j:=m+1;
while (i<=m) and (j<=q) do
 if a[i].key<a[j].key then
  begin
   b[k]:=a[i];
   inc(i);
   inc(k);
  end
 else
  begin
   b[k]:=a[j];
   inc(j);
   inc(k);
  end;
while i<=m do
 begin
  b[k]:=a[i];
  inc(i);
  inc(k);
 end;
while j<=q do
 begin
  b[k]:=a[j];
  inc(j);
  inc(k);
 end;
k:=0;
for i:=p to q do
 begin
  inc(k);
  a[i]:=b[k];
 end;
end;

procedure Srt(p,q:word);
begin
 if p<q then
  begin
   Srt(p, (p+q) div 2);
   Srt((p+q) div 2 +1, q);
   Sliv(p,q);
  end;
end;

begin
Srt(1,n);
end;


end.
