import './Styles/Chat.css';
import { sendChatMessage } from '../SocketAPI.js';
import Title from './Title'
import MessageList from './MessageList';
import SendMessageForm from './SendMessageForm';
import React from 'react';

class Chat extends React.Component {
  constructor(props) {
    super(props);
    this.sendMessage = this.sendMessage.bind(this)
  }

  sendMessage(message){
    sendChatMessage(this.props.sessionInfo.gameId, this.props.sessionInfo.username, message);
  }

  render() {
    return (
      <div className="Chat">
      <Title/>
      <MessageList messages={this.props.chat}/>
      <SendMessageForm sendMessage={this.sendMessage}/>
      </div>
    );
  }
}

export default Chat;
