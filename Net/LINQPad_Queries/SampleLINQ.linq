<Query Kind="Expression">
  <Connection>
    <ID>7f25ca1b-7efc-4ff5-9c83-e0521c961b18</ID>
    <Server>127.0.0.1</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAYX9c+zlQcUqkmtTqQcTBRQAAAAACAAAAAAAQZgAAAAEAACAAAAB17I1KVYSsa9PFddUc0ZtjxsNC6rrWoj3VgShuuL9nxgAAAAAOgAAAAAIAACAAAAAxvKhIW6YMxw4pL/uTrqlSTgWwW1z/7it9U53yq0dnzBAAAAA1P/d8A9KXI8RQrT0HUE7zQAAAAHIw4yWxR66d+6ZaRfBCYjBYWHrbEGYCsMlLbap554LAHqkoMfOODknu9cjbsDOZdbcQpHyGhV6F1Ea+OYCY0kI=</Password>
    <Database>pubs</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from x in Jobs where x.Job_id == 1 select x