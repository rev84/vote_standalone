class window.Utl
  @uuid:->
    uuid = ''
    for i in [0...32]
      random = Math.random() * 16 | 0;
      uuid += '-' if i in [8, 12, 16, 20]
      uuid += (if i is 12 then 4 else (if i is 16 then random & 3 | 8 else random)).toString(16);
    uuid

  @request:(api, params, onSuccess = (->), onFailure = (->))->
    $.ajax({
        type: "POST"
        contentType: "application/json"
        url: '/'+api
        data: JSON.stringify params
        success: onSuccess
        error: onFailure
    })


  @form_post:(endpoint, params)->
    postdata = {}
    func = (value, relay = [])->
      $.each value, (k, v)->
        relayTemp = relay.concat(k)
        if $.isArray(v) or $.isPlainObject(v)
          func v, relayTemp
        else if relayTemp.length is 1
          postdata[k] = v
        else
          postdata[relayTemp[0]+'['+relayTemp[1..].join('][')+']'] = v
    func params

    form = $('<form>').attr({
      action: endpoint
      method: 'post'
    })
    $.each postdata, (k, v)->
      form.append $('<input>').attr({
        type: 'hidden'
        name: k
        value: v
      })

    form.appendTo($('body'))
    form.submit()