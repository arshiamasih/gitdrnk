import './Styles/SendMessageForm.css';
import React from 'react';

class SendMessageForm extends React.Component {
  constructor() {
    super();
    this.state = {
       message: ''
    }
    this.handleChange = this.handleChange.bind(this)
    this.handleSubmit = this.handleSubmit.bind(this)
  }

  handleChange(e) {
    this.setState({
      message: e.target.value
    })
  }

  handleSubmit(e) {
    e.preventDefault()
    this.props.sendMessage(this.state.message)
    this.setState({
      message: ''
    })
  }

  render() {
    return (
      <div className="SendMessageForm">
        <form
          onSubmit={this.handleSubmit}
          className="send-message-form">
              <input
                onChange={this.handleChange}
                value={this.state.message}
                placeholder="Type your message and hit ENTER"
                type="text" />
        </form>
      </div>
    );
  }
}

export default SendMessageForm;
