unit Unit3;

interface
Uses Unit2, Math;

type
TClass = class(TObject)
    mszn:array ['a'..'ÿ'] of extended;
    steck:TSteck;
    Function OBP(stri:string):string;
end;

implementation

Function TClass.OBP(stri:string):string;
var
pc:0..3;
i:word;
ch1,ch:char;

 function prior(ch:char):byte;
 begin
  case ch of
  '(',')': result:=0;
  '+','-': result:=1;
  '*','/': result:=2;
  '^': result:=3;
  end;
 end;

begin
Steck:=TSteck.create();
Result:='';
for i:=1 to Length(stri) do
begin
 ch:=stri[i];
 if not (ch in ['(',')','+','-','*','/','^']) then result:=result+ch
 else if (Steck.sp1=nil) or (ch = '(') then Steck.Add(ch)
 else if ch = ')' then
  begin
   Steck.Read(ch1);
   while ch1<>'(' do
    begin
     Result:=result+ch1;
     Steck.Read(ch1);
    end;
  end
 else begin
  pc:=prior(ch);
  while (Steck.sp1<>nil) and (pc<=prior(Steck.sp1.inf)) do
   begin
    Steck.Read(ch1);
    result:=result+ch1;
   end;
  Steck.Add(ch);
 end;
end;
 While Steck.sp1<>nil do
  begin
   Steck.Read(ch);
   result:=result+ch;
  end;
 Steck.Free;
end;


end.
 