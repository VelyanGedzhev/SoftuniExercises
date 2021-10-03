function encodeAndDecodeMessages() {
    document.querySelector('button')
        .addEventListener('click', encodeAndSend);
    const outputTextArea = document.querySelectorAll('textarea')[1];
    document.querySelectorAll('button')[1]
        .addEventListener('click', decode);

    function encodeAndSend({target}) {
        const inputTextArea = target.previousElementSibling;
        const message = inputTextArea.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            let newAscii = message.charCodeAt(i) + 1;
            encodedMessage += String.fromCharCode(newAscii);
        }

        inputTextArea.value = '';
        outputTextArea.value = encodedMessage;
    }

    function decode() {
        const encodedMessage = outputTextArea.value;
        let decodedMessage = '';

        for (let i = 0; i < encodedMessage.length; i++) {
            let newAscii = encodedMessage.charCodeAt(i) - 1;
            decodedMessage += String.fromCharCode(newAscii);
        }

        outputTextArea.value = decodedMessage;
    }
}