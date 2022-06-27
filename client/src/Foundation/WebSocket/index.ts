import { useCallback, useEffect, useRef, useState } from 'preact/compat';

enum WebSocketState {
  UNINSTANTIATED = -1,
  CONNECTING = 0,
  OPEN = 1,
  CLOSING = 2,
  CLOSED = 3,
}

export const useWebSocket = (url: string) => {
  const [lastMessage, setLastMessage] = useState<any>(null);
  const websocketRef = useRef<WebSocket>(null);

  const sendMessage = useCallback((obj: object) => {
    if (websocketRef.current.readyState === WebSocketState.OPEN) {
      websocketRef.current.send(JSON.stringify(obj));
    }
  }, []);

  useEffect(() => {
    websocketRef.current = new WebSocket(url);

    websocketRef.current.onmessage = (e: MessageEvent<string>) => {
      setLastMessage(JSON.parse(e.data));
    };
  }, []);

  return {
    lastMessage,
    sendMessage,
  };
};
