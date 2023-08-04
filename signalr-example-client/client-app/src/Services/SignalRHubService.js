import * as SignalR from "@microsoft/signalr";

class SignalRHubService {
  connection = null;
  tableEvents = ["PersonTableChanged", "ProductTableChanged"];

  startConnection = (serverHubUrl) => {
    this.connection = new SignalR.HubConnectionBuilder()
      .withUrl(serverHubUrl)
      .configureLogging(SignalR.LogLevel.Information)
      .build();

    this.connection.start().catch((error) => {
      console.error(error);
    });
  };

  addTableChangeListner = (tableEvent, callback) => {
    if (this.isEventAndConnectionValid(tableEvent, this.connection)) {
      this.connection.on(tableEvent, (tableChangeModel) => {
        callback(tableChangeModel);
      });
    } else {
      console.error("Can't Add Listner with Invalid Connection or Event");
    }
  };

  isEventAndConnectionValid = (tableEvent, connection) => {
    if (!connection) {
      console.error("Can't Add Listner with Invalid Connection");
      return false;
    }

    if (!tableEvent.includes(tableEvent)) {
      console.error("Can't Add Listner For unknow event");
      return false;
    }

    return true;
  };
}

export default SignalRHubService;
