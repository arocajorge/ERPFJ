﻿
create view vwro_empleado_historial_Sueldo_actual as
select IdEmpresa,IdEmpleado,max(SueldoActual)SueldoActual,MAX(Secuencia)Secuencia from ro_empleado_historial_Sueldo
group by IdEmpresa,IdEmpleado