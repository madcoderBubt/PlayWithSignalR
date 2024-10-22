import { Injectable } from '@angular/core';
import * as SignalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class ChatHubService {
  private hubCon? : SignalR.HubConnection;
  private datas: string[] = [];

  constructor() {
    this.startConnection();
   }

  private startConnection() {
    this.hubCon = new SignalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/Chat') // Replace with your hub URL
      .withAutomaticReconnect()
      .build();

    this.hubCon
      .start()
      .then(() => console.log('SignalR connection started'))
      .catch((err) => console.log('Error while starting SignalR connection: ' + err));
  }

  private ReceiveMessages(){
    this.hubCon?.on("RecieveMessage", (user:string, message:string) =>{
      this.datas.push(`${user}: ${message}`);
    })
  }

  private SendMessage(user:string, message:string){
    this.hubCon?.invoke("SendMessage", user, message)
    .catch(err=> console.error(err))
  }
}
