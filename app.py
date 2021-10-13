from flask import Flask, jsonify, request
import requests

app = Flask(__name__)


@app.route("/<string:isim>")
def baslangic_api(isim: str):
    # isim = request.args.get("isim")
    return jsonify(data=isim), 200


@app.route("/telegram")
def telegram_bot_sendtext():
    nick = parametre_ekle("nick")
    bot_message = parametre_ekle("bot_message")
    bot_token = '1888334307:AAH2niT-IC2y431uZ0TNelGsgMM83L0mZUI'
    bot_chatID = nick
    send_text = 'https://api.telegram.org/bot' + bot_token + '/sendMessage?chat_id=' + bot_chatID + '&parse_mode' \
                                                                                                    '=Markdown&text=' \
                + bot_message

    response = requests.get(send_text)

    return jsonify(response.json())





def parametre_ekle(x):
    return request.args.get(x)





if __name__ == "__main__":
    app.run()
