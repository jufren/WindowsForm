alter database ContosoUniversity2 set enable_broker with rollback immediate;

GRANT SUBSCRIBE QUERY NOTIFICATIONS TO "Domain\ASPNET"

CREATE QUEUE ContactChangeMessages;  
  
CREATE SERVICE ContactChangeNotifications  
  ON QUEUE ContactChangeMessages  
([http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification]);  

