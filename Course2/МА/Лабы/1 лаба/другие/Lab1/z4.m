% ������� 4. ������������ ������������������ ����
syms n l f
f = ((-1)^(n-1)) / (2^(2*n) * (n+1));
l = limit(abs(f), n, inf);
disp('������ �������� ������������������ (������� ��������):');
disp(l)
if (l == 0)
    disp('��� ��������!');
    syms f_lim
    f_lim = limit(abs(f)^(1/n), n, inf);
    disp('������ �� ����:');
    disp(f_lim);
    f_lim = double(f_lim);
    if (f_lim < 1)
        disp('�������� ��� �������� ���������!');
    elseif (f_lim > 1)
        disp('�������� ��� �������� �������!');
    else
        disp('����� �������������� ������������');
    end;
else
     disp('��� ����������!');
end;
% ���������: ������ �������� ������������������ (������� ��������) = 0
% ���������: ��� ��������
% ���������: ������ �� ���� = 1/4
% ���������: �������� ��� �������� ���������