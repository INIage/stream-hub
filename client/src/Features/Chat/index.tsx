import Preact, { useEffect, useMemo, useRef, useState } from 'preact/compat';
import { useSelector } from 'react-redux';

import { selector } from 'Foundation/GoodGame/User';
import { useWebSocket } from 'Foundation/WebSocket';

import './styles.scss';

export const Chat: Preact.FC = () => {
  const [usersCount, setUsersCount] = useState(0);
  const user = useSelector(selector.GetUser);
  const messages = useRef([]);

  const { lastMessage, sendMessage } = useWebSocket('wss://localhost:5001/chat');

  messages.current = useMemo(() => {
    if (lastMessage?.type == 'message') {
      return messages.current.concat(lastMessage.data);
    }
    return messages.current;
  }, [lastMessage]);

  useEffect(() => {
    switch (lastMessage?.type) {
      case 'channel_counters':
        setUsersCount(lastMessage.data.users_in_channel);
        break;
      case 'welcome':
        const responce = {
          data: {
            goodgame: user,
          },
          type: 'join',
        };
        sendMessage(responce);
        break;
      default:
        break;
    }
  }, [lastMessage]);

  return (
    <main id="chat">
      <div class="wrapper">
        <div class="chat">
          {messages.current.map(message => {
            return <span key={message.message_id}>{`${message.user_name}: ${message.text}`}</span>;
          })}
        </div>
        <div class="chat-stats">{usersCount}</div>
      </div>
    </main>
  );
};
