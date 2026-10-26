
alter table prl_projectlistGAPRO drop column prl_month
go

alter table prl_projectlistGAPRO add prl_month varchar(255) default '' NOT NULL
go