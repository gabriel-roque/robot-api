CREATE EXTENSION "uuid-ossp";

create table if not exists public.robots
(
    id uuid default uuid_generate_v4() not null
    constraint robots_pk
    primary key,
    name varchar(10) not null
    );

create unique index if not exists idx_robots_id
    on public.robots (id);



