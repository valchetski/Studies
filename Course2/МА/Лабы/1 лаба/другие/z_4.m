 %������������ ���������������� ���� �� ����������
%���: (-1)^n*(n+1)/n^(3/2) n=1,2...
syms p l f n
f = diff((n+1)/n^(3/2),n);
%assume (n>=1);
%���� ��� ��������� ������� ������� � 1 �����
if(isAlways(f<0))
    %������� ��������
    l = limit((n+1)/n^(3/2),n,inf);
    if(l == 0)
        %������� �'��������
        p = limit(((n+2)*n^(3/2))/((n+1)^(5/2)),n,inf);
        if(p == 1)
            %������������ �������
            p = limit(n*(n+1)/n^(3/2),n,inf);
            if(p ~= inf) && (p~=0)
                disp('�������� �������');
            else
                disp('�������� ���������');
            end;                
        elseif(p>1)
            disp('�������� �������');
        else 
            disp('�������� ���������');
        end;
    else
        disp('������� �� �����������, ��� ����������');
    end;
else 
    disp('������� �� �����������, ��� ����������');
end;
%���������: �������� �������