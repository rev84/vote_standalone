$().ready ->
  $('#submit').on 'click', post

post = ->
  ###
  Fetch.request('/create_user_submit', {
    uuid: Utl.uuid(),
    display_name: $('#display_name').val()
  })
  ###
  Utl.request('/create_user_submit', {
    uuid: Utl.uuid(),
    display_name: $('#display_name').val()
  })